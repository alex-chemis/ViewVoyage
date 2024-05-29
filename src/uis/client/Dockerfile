FROM node:16

WORKDIR /app

COPY /src/uis/client/package.json .
COPY /src/uis/client .

RUN npm install

EXPOSE 5173

CMD ["npm", "run", "dev", "--", "--host"]
