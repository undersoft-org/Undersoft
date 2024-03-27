export function removeExpandIcon(id) {
    var item = document.getElementById(id);
    if (!!item) {
        var shadow = item.shadowRoot;
        for (let node of shadow.childNodes) {
            var icons = node.getElementsByClassName("icon");
            if (!!icons) {
                for (let e of icons) {
                    e.remove();
                }
            }
            if (node.className === "region") {
                node.style = "padding:0px; background:var(--neutral-fill-stealth-rest);";
            }
        }
    }
}