var abp = abp || {};

(function () {
    window.addEventListener('DOMContentLoaded', (event) => {
        var excludeUrl = ["swagger.json", "connect/token"]
        var firstRequest = true;

        /*
          Ensure that the DOM is loaded, then add the event listener.
          here we are listenig to 'before-try' event which fires when the user clicks
          on TRY, it then modifies the POST requests by adding a custom header
        */
        const rapidocEl = document.getElementById('thedoc');
        rapidocEl.addEventListener('before-try', async (e) => {
            var request = e.detail.request;
            if (request.url.includes(excludeUrl[1])) {
                firstRequest = true;
            }

            if (firstRequest && !excludeUrl.some(url => request.url.includes(url))) {
                await fetch(`${abp.appPath}abp/Swashbuckle/SetCsrfCookie`, {
                    headers: request.headers
                });
                firstRequest = false;
            }

            var antiForgeryToken = abp.security.antiForgery.getToken();
            if (antiForgeryToken) {
                request.headers.append(abp.security.antiForgery.tokenHeaderName, antiForgeryToken);
            }
        });
    });
})();