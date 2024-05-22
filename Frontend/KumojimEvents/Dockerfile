### STAGE 1:BUILD ###
# Defining a node image to be used as giving it an alias of "build"
# Which version of Node image to use depends on project dependencies 
# This is needed to build and compile our code 
# while generating the docker image
FROM node:20.13.1-alpine AS build
# BASE_URL AS ENV VAR
ENV BASE_URL='http://localhost:5120'
# Create a Virtual directory inside the docker image
WORKDIR /dist/src/app
# Copy files to virtual directory
# COPY package.json package-lock.json ./
# Run command in Virtual directory
RUN npm cache clean --force
# Copy files from local machine to virtual directory in docker image
COPY . .
RUN npm install
RUN npm run build --prod
RUN ls -l /dist/src/app/dist/kumojim-events

### STAGE 2:RUN ###
# Defining nginx image to be used
FROM nginx:latest AS nginx
# Copying compiled code and nginx config to different folder
# NOTE: This path may change according to your project's output folder 
COPY --from=build /dist/src/app/dist/kumojim-events/browser /usr/share/nginx/html
COPY /nginx.conf  /etc/nginx/conf.d/default.conf
# Cpying the bentrypoint script as user data
COPY entrypoint.sh /usr/share/nginx/html
RUN chmod +x /usr/share/nginx/html/entrypoint.sh
# Exposing a port, here it means that inside the container 
# the app will be using Port 80 while running
# EXPOSE 80
ENTRYPOINT ["./usr/share/nginx/html/entrypoint.sh", "$BASE_URL"]