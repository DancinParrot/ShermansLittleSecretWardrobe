window.addEventListener("load", () => {

    const qrstr = generatePayNowStr(opts);
    new QRCode(document.getElementById("qrcode"),
        {
            text: qrstr,
            width: 150,
            height: 150
        });
});