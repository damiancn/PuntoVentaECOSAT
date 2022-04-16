const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:4969';

const PROXY_CONFIG = [
  {
    context: [
      "/api/Usuario",
      "/api/venta",    
      "/api/producto", 
      "/Test",   
      "/weatherforecast",
   ],
    target: target,
    secure: false,
    // headers: {
    //   Connection: 'Keep-Alive'
    // }
  }
]

module.exports = PROXY_CONFIG;