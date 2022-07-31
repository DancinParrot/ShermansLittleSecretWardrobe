window.addEventListener("load", () => {
    const qrstr = generatePayNowStr(opts);

    var dropdown = document.getElementById("payment-dropdown");
    try {
        var dropdownValue = dropdown.value;

        console.log(dropdownValue);
        if (dropdownValue == "Paynow") {
            new QRCode(document.getElementById("qrcode"),
                {
                    text: qrstr,
                    width: 150,
                    height: 150
                });
            document.getElementById("payment-form").style.display = "block";
        }
    }
    catch (e) {
        console.log(e);
    }


    $("#payment-dropdown").on('change', function () {
        var selectedValue = $(this).val();

        if (selectedValue == 'Paynow') {
            new QRCode(document.getElementById("qrcode"),
                {
                    text: qrstr,
                    width: 150,
                    height: 150
                });
            document.getElementById("payment-form").style.display = "block";
        }
        else {
            document.getElementById("payment-form").style.display = "none";
        }
    });
});


