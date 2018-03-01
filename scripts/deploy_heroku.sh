docker-compose build --force-rm
docker login --username=_ --password=$api_key registry.heroku.com
docker tag souzaciquoting.webapi registry.heroku.com/souzaciquoting/web
docker push registry.heroku.com/souzaciquoting/web