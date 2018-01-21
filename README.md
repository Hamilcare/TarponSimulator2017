# Tarpon Simulator 2017

[![Build Status](https://ci.deuxfleurs.fr/job/TarponSimulator2017/job/master/badge/icon)](https://ci.deuxfleurs.fr/job/TarponSimulator2017/job/master/)

## Play it!

 1. Install dependencies
   * On Linux, you must install SDL2 and mono. On Fedora: `dnf install mono SDL2 SDL2-devel`
   * On macOS, you must install SDL2 and mono, we don't know how.
   * On Windows, you have nothing to do.
 2. [Download Tarpon Simulator 2017 binaries (Windows and Linux)](https://ci.deuxfleurs.fr/job/TarponSimulator2017/job/master/lastSuccessfulBuild/artifact/TarponSimulator2017.zip)
 3. Unzip it and launch it
   * On Windows, just double click on `TarponSimulator2017.exe`
   * On Linux and macOS, run `mono TarponSimulator2017.exe`

*I don't know yet why SDL2-devel is required on Fedora*

## Hack it!

We are developing the game under Fedora (and the following instructions are for Fedora), but it is theorically possible to develop it from macOS or Windows.

```bash
# Install dependencies
sudo dnf install -y monodevelop zip SDL2 SDL2-devel nuget ca-certificates nunit2 gtk-sharp3 gtk-sharp3-devel

# Install certificates for nuget
sudo cert-sync /etc/pki/tls/certs/ca-bundle.crt

# Install monogame
curl http://www.monogame.net/releases/v3.6/monogame-sdk.run -o ./monogame-sdk.run
chmod +x monogame-sdk.run
sudo ./monogame-sdk.run

# Clone the project
git clone https://github.com/Hamilcare/TarponSimulator2017.git
cd TarponSimulator2017

# Our version of monodevelop crashes if it find a .git folder
# We will rename .git to .git2 and use an alias, git2, to use git from command line
mv .git .git2
echo 'alias git2="git --git-dir=.git2"' >> ~/.bashrc
source ~/.bashrc
git2 status

# Edit resources
monogame-pipeline-tool

# Launch editor
monodevelop
```

Our automated build id described in the `Dockerfile` and the `Jenkinsfile`.
You can inspect them if you have a problem with the previous commands.

## Credits

 * [Pirate Pack](https://kenney.nl/assets/pirate-pack) under [CC0 1.0 Universal](https://creativecommons.org/publicdomain/zero/1.0/) by [Kenney.nl](https://kenney.nl/)
