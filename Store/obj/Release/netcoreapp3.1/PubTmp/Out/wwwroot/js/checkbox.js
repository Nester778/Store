const out = document.querySelector('.screen');
const check = document.querySelector('.table');

checkbox();

console.log(sessionStorage.getItem("sum"));
if (sessionStorage.getItem("sum") === null)
    out.textContent = 0;
else
    out.textContent = sessionStorage.getItem("sum");


check.onclick = function (event) {
    //const IsChecked = check.checked.type;
    sessionStorage.setItem("sum", 0);
    if (event.target.type === 'checkbox') {
        const select = document.querySelectorAll('.checkbox')
        
        for (let i = 0; i < select.length; i += 1) { 
            
            if (select[i].checked) {
                const amount = document.getElementById(select[i].id);
                console.log(amount.value);
                sessionStorage.setItem(select[i].id, amount.value);
            }
            else {
                sessionStorage.removeItem(select[i].id);
            }
        }

        
        sessionStorage.setItem("sum", 0);
        for (let i = 0; i < sessionStorage.length; i += 1) {

            if (sessionStorage.key(i) != "sum") {
                
                sessionStorage.setItem("sum", Number(sessionStorage.getItem("sum")) + Number(sessionStorage.getItem(sessionStorage.key(i))));
            }
        }
        out.textContent = sessionStorage.getItem("sum");
    }

}

function checkbox() {
    let input = document.querySelectorAll('.checkbox');
    for (let i = 0; i < input.length; i += 1) {
        for (let j = 0; j < sessionStorage.length; j += 1) {
            if (input[i].id === sessionStorage.key(j)) {
                input[i].checked = true;
            }
        }
    }
}

