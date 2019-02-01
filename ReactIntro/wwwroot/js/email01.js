
let root = document.getElementById("root");


class Textruta extends React.Component {

    state = {valid: false}

    validate1 = (event) => {

        let x = event.target.value

        if (x == this.props.validera) {

        }
        this.setState(() => { 
            return {
                valid: true
            };
        })
    }


    render() {
        return (
            <div>
                <div className="textwrap">
                    <label>{this.props.lejbel}</label>
                    <input onChange="this.validate1()" />
                </div>
            </div>
        );
    }
};

class App extends React.Component {

    render() {
        return (
            <div>
                <Textruta lejbel="Förnamn" />
                <Textruta lejbel="Efternamn" validera="son$" />
                <Textruta lejbel="Email" validera="\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b" ignoreracasing="true" />
            </div>
        )
    }

};


ReactDOM.render(<App/>, root);