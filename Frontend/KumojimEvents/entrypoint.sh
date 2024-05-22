#!/bin/sh
sed -i "s#API_BASE_URL#$BASE_URL#g" /usr/share/nginx/html/main-*.js
nginx -g 'daemon off;'