cd wwwsrc
npm run build
cd ..
dotnet publish -c Release
docker build -t keepr-demo ./
docker tag keepr-demo registry.heroku.com/keepr3/web
docker push registry.heroku.com/keepr3/web
heroku container:release web -a keepr3
echo press any key
read end