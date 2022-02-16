function Welcome(person: string) {
    return "<h2>Hello " + person + ", Lets learn TypeScript</h2>";
}

function ClickMeButton() {
    let user: string = "Sandra";
    document.getElementById("divMsg").innerHTML = Welcome(user);
}