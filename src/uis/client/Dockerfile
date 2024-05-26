FROM node:18-alpine

WORKDIR /app

COPY /src/uis/Client/package.json .

RUN npm install

COPY /src/uis/Client .

EXPOSE 3030

CMD ["npm", "run", "dev"]
