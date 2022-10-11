### STAGE 1: Build ###
FROM node:14 AS build
WORKDIR /usr/local/app
#COPY package.json package-lock.json ./
COPY ./ /usr/local/app/
RUN npm install
#COPY . .
RUN npm run build

### STAGE 2: Run ###
FROM nginx:1.23-alpine
COPY --from=build /usr/local/app/dist/AngularClient /usr/share/nginx/html
EXPOSE 80
