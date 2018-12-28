# TF2 Server Manager
#### Made with love by: [Crazy..](https://www.youtube.com/crazydotdot)
Do you think it's frustrating to create your own Team Fortress 2 server? Fear no more, a brand new tool has arrived that aims to make creating multiple servers a breeze. Simply add a server, configure general settings, run the updater and start playing!
### How does it work?
The manager acts as a wrapper around the traditional way of creating a server. Let's break it down into some simple steps:
1. Add a server.
2. Give it a name, this is also going to be the hostname for the server.
3. Type in a folder name, this will be the folder containing **SteamCMD** and the server files inside the servers directory.
4. *(Optional)* Change the host ip address, or leave it as `0.0.0.0`, which means it hosts on all network interfaces.
5. *(Optional)* Choose another game port.
6. *(Optional)* Enter a different map name, but make sure it exists in `"{Servers Directory}\{Folder Name}\Server\tf\maps"`
7. *(Optional)* Increase/decrease the amount of player slots.
8. Click **Run Updater**, say yes to downloading **SteamCMD** and wait for the download to complete.
9. Close the updater window and hit **Start** (it will attempt to create a port mapping).
10. Copy the public server ip address and port and send it to your friends!
### Potentially upcoming features.
- One-click **SourceMod** installation.
- **SourceMod** permissions configurator, like adding admins/admin groups.
- A configurator for **server.cfg**.
- Automatic updating (this one is a bit tricky).
- Automatically start the server again if it crashes.
- Server restart interval, so you can perform a daily restart.
- A fast download server for your servers, running on your own PC with **ASP.NET Core**.
- Setting the game server account for your servers, so they stay in people's favorites if your public ip address changes.
### References
- **Newtonsoft.Json** - https://github.com/JamesNK/Newtonsoft.Json
- **Open.NAT** - https://github.com/lontivero/Open.NAT
### Contributing
Contributes are always welcome, but please use the same coding convention as the project.
### Licenses
- This project is licensed under the [GPL-3.0 license](https://github.com/mrphil2105/TF2-Server-Manager/blob/master/LICENSE).
- **Newtonsoft.Json** is licensed under the [MIT license](https://github.com/JamesNK/Newtonsoft.Json/blob/master/LICENSE.md).
- **Open.NAT** is licensed under the [MIT license](https://github.com/lontivero/Open.NAT/blob/master/LICENSE).
