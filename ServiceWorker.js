const cacheName = "DefaultCompany-KINGRoom-0.0.7";
const contentToCache = [
    "Build/WebGL.loader.js",
    "Build/cccb55245bdf70095b0aa2fbad857a15.js",
    "Build/ba76c0cd41b7332e82a1727a2ddc22da.data",
    "Build/f59463d42553f4456088fea84ee1ddfa.wasm",
    "TemplateData/style.css"

];

self.addEventListener('install', function (e) {
    console.log('[Service Worker] Install');
    
    e.waitUntil((async function () {
      const cache = await caches.open(cacheName);
      console.log('[Service Worker] Caching all: app shell and content');
      await cache.addAll(contentToCache);
    })());
});

self.addEventListener('fetch', function (e) {
    e.respondWith((async function () {
      let response = await caches.match(e.request);
      console.log(`[Service Worker] Fetching resource: ${e.request.url}`);
      if (response) { return response; }

      response = await fetch(e.request);
      const cache = await caches.open(cacheName);
      console.log(`[Service Worker] Caching new resource: ${e.request.url}`);
      cache.put(e.request, response.clone());
      return response;
    })());
});
