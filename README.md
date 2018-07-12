### EOL notice
Please note that I will no longer be maintaining this project. As it stands, the application achieves the original requirements. Thanks to those that contributed issues, code and to the users. I've noticed the usage of the application decline, I'm also no longer using it myself. the shrew client itself hasn't been maintained for about 5 years now.

# shrew-reconnect
Manages Shrew Soft VPN client and connection. Reconnects when the connection is dropped.
###### Download installer from: https://github.com/CamW/shrew-reconnect/raw/master/installers/ShrewReconnectLatest64.msi

![](https://raw.githubusercontent.com/CamW/shrew-reconnect/master/documentation/images/open.png)
![](https://raw.githubusercontent.com/CamW/shrew-reconnect/master/documentation/images/connected.PNG)

#### What shrew-reconnect is
shrew-reconnect manages a Shrew Soft VPN client on windows (https://www.shrew.net/download/vpn) and the VPN connection which it creates. It will monitor the connection and try to reconnect if the connection drops. It also hides the Shrew Soft VPN client window and minimizes itself to the tray for a less intrusive VPNing experience. shrew-reconnect was built to avoid having to reconnect the Shrew Soft VPN client manually each time the connection drops.

#### What shrew-reconnect is not
shrew-reconnect is not a stand alone VPN client. You need the original Shrew Soft VPN client installed.

#### Features
* Watches Shrew Soft VPN and reconnects when connection is dropped.
* Ensures that Shrew Soft VPN services are running before trying to connect.
* Securely stores connection information using Microsoft DPAPI to prevent having to specify it each time you connect.
* Allows you to automatically connect to a VPN on application startup.
* Allows you to hide/show the Shrew Soft VPN client window to reduce desktop clutter.
* Minimizes to a tray icon (double click the icon to re-open)
* Tray icon shows the VPN status with different icon background colors.
    * Green: VPN is connected.
    * Yellow: One of the following:
      * VPN has not been connected by the user.
      * VPN has been disconnected by the user.
      * VPN has been disconnected but is in the process of reconnecting for the 1st time since the disconnect.
    * Red: VPN Could not connect or failed to reconnect.

#### Limitations
* The app requires that the original Shrew Soft VPN client be installed at the default C:\Program Files\ShrewSoft\VPN Client\ipsecc.exe location - may be externalized as a setting later.

#### Using shrew-reconnect
##### Installation
There is a prebuilt MSI installer available from https://github.com/CamW/shrew-reconnect/raw/master/installers/ShrewReconnectLatest64.msi (64-bit) or https://github.com/CamW/shrew-reconnect/raw/master/installers/ShrewReconnectLatest32.msi (32-bit). or you can download the source, build it, build the MSI and install that.

##### Running
Once installed, there will be a "Shrew VPN Reconnect" icon on your desktop. Double click that to open. You'll notice, if you have UAC enabled, that it required administrative privileges. This is because it checks to see that the Shrew Soft VPN windows services are running and starts them if they are not. It will also restart them after 10 failed connect attempts as they do seem to get stuck in bad states from time to time.

##### Connecting
Before connecting with shrew-reconnect you will first need to setup the connection in the Shrew Soft VPN Access Manager as you usually would.
Please note, Shrew reconnect needs administrative privileges to run. It therefore will ask for admin credentials if the user you run it under is not an administrator. It will look for the .vpn file in the roaming folder of the used administrative user. If you elevate from a limited account, this won't be the current user. This can be confusing since Shrew does store it's .vpn in the current user. You need to either copy the .vpn to the administrative user, or (quite probably, but untested) do the configuration of Shrew elevated as well.

Once you've opened shrew-reconnect. Type the name of the VPN you'd like to connect to as it appears in the Shrew Soft VPN Access Manager into the "Site Config Path" field. Type in your VPN username and password into the available fields. If you'd like these encrypted and saved for next time, click the "Encrypt..." checkbox.
Click the connect button.
