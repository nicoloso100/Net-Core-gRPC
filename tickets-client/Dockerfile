FROM node:16.3.0-alpine

WORKDIR /app

ENV PATH /app/node_modules/.bin:$PATH

COPY tickets-client/package.json ./
COPY tickets-client/package-lock.json ./
RUN npm install --silent
RUN npm install react-scripts@3.4.1 -g --silent

COPY tickets-client/ ./

CMD ["npm", "start"]