FROM node:lts-alpine

WORKDIR /app/web-app

COPY ./web-app/package*.json ./

RUN npm install -g http-server
RUN npm install

COPY ./web-app .

RUN npm run build

ENV PORT=3000

EXPOSE 3000

CMD [ "http-server", "dist" ]