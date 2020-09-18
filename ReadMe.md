docker rm -vf $(docker ps -a -q)
docker rmi -f $(docker images -a -q)
docker run -d -p 5100:6100 --name dlwmsuiteng3 dlwmsuiteng

dl-wm-suite

dotnet publish
dotnet <name.dll>

dotnet publish
dotnet dl-wm-suite-auth.api.dll

htop -d 10

apt show htop

nohup dotnet dl-wm-suite-auth.api.dll &
nohup dotnet dl-wm-suite-telemetry.api.dll &
nohup dotnet dl-wm-suite-interprocess.api.dll &
nohup dotnet dl-wm-suite-cms.api.dll &
nohup dotnet dl-wm-suite-fleet.api.dll &
ps aux1
kill -SIGTERM 3139ls

sudo mkdir /opt/aegis-wm
sudo chmod a+rwx /opt/aegis-wm

ssh iotaegis@52.178.154.16
1234567890q!
ssh wmaegis@137.116.232.108
1234567890q!1

auth.api
urls: "http://0.0.0.0:6100"
http://137.116.232.108:6100/swagger/index.html

crm.api
urls: "http://0.0.0.0:6200"
http://137.116.232.108:6200/swagger/index.html

interprocess.api
urls: "http://0.0.0.0:6300"
http://137.116.232.108:6300/swagger/index.html

dms.api
urls: "http://0.0.0.0:6400"
http://137.116.232.108:6400/swagger/index.html

telemetry.api
urls: "http://0.0.0.0:6500"
http://137.116.232.108:6500/swagger/index.html

fleet.api
urls: "http://0.0.0.0:6600"
http://137.116.232.108:6600/swagger/index.html


dotnet publish ./dl-wm-suite-auth.api.csproj -c Release -o app

dotnet publish ./dl-wm-suite-cms.api.csproj -c Release -o app

dotnet publish ./dl-wm-suite-interprocess.api.csproj -c Release -o app

dotnet publish ./dl-wm-suite-telemetry.api.csproj -c Release -o app



