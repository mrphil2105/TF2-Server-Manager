using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using ServerManager.Extensions;

namespace ServerManager.Core
{
    public class SteamCMDParser
    {
        private const string UPDATE_STATE_REGEX = @"^ Update state \(0x[\d]+?\) (?<state>[a-z]+?), progress: [\d]+?\.[\d]+? \((?<processed>[\d]+?) \/ (?<total>[\d]+?)\)$";
        private const string NON_ENGLISH_ERROR = "cannot run from a folder path that includes non-English characters.";

        private readonly Form _form;

        public SteamCMDParser(Form form)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
            }

            UpdateState = "Unknown";
            _form = form;
        }

        public string UpdateState { get; private set; }

        public long Processed { get; private set; }

        public long Total { get; private set; }

        public void ParseLine(string line)
        {
            if (line == null)
            {
                throw new ArgumentNullException(nameof(line));
            }

            if (line.StartsWith("Success!"))
            {
                UpdateState = "Success";
                Processed = Total;

                if (line.Contains("already up to date"))
                {
                    _form.ShowMessage("The server is already up to date.", "No Updates");
                }
                else
                {
                    _form.ShowMessage("The update process has completed successfully!", "Update Successful");
                }

                return;
            }

            if (line.StartsWith("Error!"))
            {
                UpdateState = "Error";
                _form.ShowError("An error has occurred when running SteamCMD.", "Error Running SteamCMD");
                return;
            }

            if (line.Contains(NON_ENGLISH_ERROR))
            {
                UpdateState = "Error";
                _form.ShowError("SteamCMD cannot run from a path that contains non-English characters, please change the servers directory in " +
                    "Help > Settings > General.", "Non-English Characters");
                return;
            }

            ParseProgress(line);
        }

        private void ParseProgress(string line)
        {
            var regex = new Regex(UPDATE_STATE_REGEX);
            var match = regex.Match(line);

            if (match != Match.Empty)
            {
                foreach (int groupNumber in regex.GetGroupNumbers())
                {
                    string value = match.Groups[groupNumber].Value;

                    switch (groupNumber)
                    {
                        case 1:
                            UpdateState = char.ToUpper(value[0]) + value.Substring(1);
                            break;
                        case 2:
                            Processed = long.Parse(value);
                            break;
                        case 3:
                            Total = long.Parse(value);
                            break;
                    }
                }
            }
        }
    }
}
