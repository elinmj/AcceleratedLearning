
console.log('Hello from tmp.js');

let root = document.getElementById("root");


class Button extends React.Component {

    state = { counter: 1, counterM: 1}

    handleClick = () => {

        this.setState((x) => {
            return {
                counter: x.counter + 1
            };
        })
    }

    overMouse = () => {

        this.setState((y) => {
            return {
                counterM: y.counterM + 1
            };
        })
    }

    render() {
        return (
            <div>
                <button onClick={this.handleClick} onMouseOver={this.overMouse}>
                    Click {this.state.counter}
                    Mouse over {this.state.counterM}
                </button>
            </div>
            )
    }
}

ReactDOM.render(<Button />, root);

//Kan skicka in props i funktionen
//const Knapp = function () {
//    return (
//        <button>Go</button>
//    );
//}


//Render vill bara ha ett objekt = har satt allt inom en div
//En ny rednder skriver över den senaste
//ReactDOM.render(
//    <div>
//        <Knapp />
//        <Knapp />
//    </div>, root);
