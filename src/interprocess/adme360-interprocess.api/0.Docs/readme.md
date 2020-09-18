docker build -t magic-button-collector.api .

nohup dotnet magic-button-collector.api.dll &

http://192.168.1.14:5100/swagger/index.html

dmesg | grep tty

getent group dialout

ps aux 
kill -SIGTERM 
dmesg | grep tty

sudo usermod -a -G dialout $USER

groups
compgen -g
sudo usermod -a -G tty $USER

sudo gpasswd --add ${USER} dialout

chmod -R 0777 Logs/
