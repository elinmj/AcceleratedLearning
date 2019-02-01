
let root = document.getElementById("root");


class Button extends React.Component {


    state = { texten: '',textenReverse: '' }

    TextInput = (event) => {

        let word = event.target.value

        this.setState(() => {
            return {
                texten: word
            };
        })
    }

    TextInputReverse = (event) => {

        let word = event.target.value
        let array = word.split('');
        let newArray = array.push(array.shift());
        let wordReverse = newArray.join('');

        this.setState(() => {
            return {
                textenReverse: wordReverse
            };
        })
    }

    render() {
        return (
            <form>
                <input type="text" onChange={this.TextInput} value={this.state.texten} />
                <input type="text" onChange={this.TextInput} value={this.state.texten} />
                <input type="text" onChange={this.TextInput} value={this.state.texten} />
                <input type="text" onChange={this.TextInputReverse} value={this.state.textenReverse} />
                <input type="text" onChange={this.TextInput} value={this.state.texten} />

            </form>
        );
    }

};


ReactDOM.render(<div><Button /></div>, root);