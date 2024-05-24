FROM nginx:alpine

COPY /src/gateways/AuthGateway/nginx.conf /etc/nginx/nginx.conf

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]