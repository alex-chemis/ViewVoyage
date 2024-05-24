FROM nginx:alpine

COPY /src/gateways/Gateway/nginx.conf /etc/nginx/nginx.conf

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]