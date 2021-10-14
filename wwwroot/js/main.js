"use strict";

if (!window.ToastNotify) {
    window.ToastNotify = async function (data) {
            alert(data);

            let notify = document.createElement("div");
            notify.innerHTML = window.NotifyTemplate.replace("[[Title]]", data.Title);
            document.appendChild(notify);
            setTimeout(function () {document.removeChild(notify);}, data.Timeout)
            
    }

    window.NotifyTemplate = `
    <div class="position-fixed bottom-0 end-0 p-3" style="z-index: 5">
      <div id="liveToast" class="toast hide" role="alert" aria-live="assertive" aria-atomic="true">
        <div class="toast-header">
          <span class="oi oi-[[Icon]]"></span>
          <strong class="me-auto">[[Title]]</strong>
          <small>[[SubTitle]]</small>
          <button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"></button>
        </div>
        <div class="toast-body">
          [[Body]]
        </div>
      </div>
    </div>
    `;
}