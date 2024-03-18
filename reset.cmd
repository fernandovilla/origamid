git config --global --unset user.name
git config --global --unset user.email
git config --global --unset credential.helper
cmdkey /delete:LegacyGeneric:target=git:https://github.com
git config --global user.name "username"
git config --global user.email emailaddr
git config  credential.helper ´store´
git remote add origin repolink
git remote -v
git init 