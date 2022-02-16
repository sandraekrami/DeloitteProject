const { env } = require('process');


const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:52489';

const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast",
   ],
    target: target,
    secure: false,
    headers: {
      Connection: 'Keep-Alive'
    }
  },
  {
    "/api/*": {
      "target": "http://localhost:7019",
      "secure": false,
      "logLevel": "debug"
    }
  }
]



module.exports = PROXY_CONFIG;
