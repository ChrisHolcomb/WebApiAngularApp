# .Net Core 6 Web Api

Creates a .Net Core 6 Web Api backend for the Angular Tour of Heroes Tutorial

# Docker 
Create the Docker Container for the MongoDB database using
```text
 docker run -it --rm --name mongodb -p 27017:27017 mongo
```
---

First, create the docker image from the Dockerfile. From the project root run
```text
docker build -t hero.webapi:0.0.1 .
```

---

Once the image is built you can run the image in docker with
```text
docker run -it --rm --name hero-web-api -p 7000:7000  hero.webapi:0.0.1 \
-e MongoDbSettings:Host="172.17.0.1"

```

---

This will start the docker container in Interactive Mode meaning when you press Ctrl + C it will terminate the 
docker container and the app sill stop. If you want to run it in Detached mode then replace "-it" with "-d". 
Also I have added the MongoDB HostName pointing to the IP Address of the Docker Container for the MongoDB since localhost 
was pointing to the container itself not the dev machine running it.

# TODO
Next step is to make this work with Kubernetes and Helm
