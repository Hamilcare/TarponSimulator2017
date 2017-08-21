# Tarpon Simulator 2017

[![Build Status](https://ci.deuxfleurs.fr/job/TarponSimulator2017/job/master/badge/icon)](https://ci.deuxfleurs.fr/job/TarponSimulator2017/job/master/)

## Download

[Download Tarpon Simulator 2017 binaries (Windows and Linux)](https://ci.deuxfleurs.fr/job/TarponSimulator2017/job/master/lastSuccessfulBuild/artifact/TarponSimulator2017.zip)

## Known issue


### Monodevelop crashes if it finds a .git folder

One possible fix is to rename your `.git` folder in a `.batard` folder and use the `--git-dir=` for each git commands.

An example using the alias command :

```bash
mv .git .batard
alias batard="git --git-dir=.batard"
batard status
batard log
batard commit -a -m "blablab"
batard pull
batard push
```
