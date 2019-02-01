console.log('Hello from text01.js');

let root = document.getElementById("root");


class Button extends React.Component {
    

    state = { texten: ''}

     TextInput = (event) => {

        let word = event.target.value
         
        this.setState(() => {
        return {
            texten: word
        };
        })
    }
     
    render() {
        return (
            <form>
                <input type="text" onChange={this.TextInput} value={this.state.texten} />
                <input type="text" onChange={this.TextInput} value={this.state.texten} />
                <input type="text" onChange={this.TextInput} value={this.state.texten} />
                <input type="text" onChange={this.TextInput} value={this.state.texten} />
                <input type="text" onChange={this.TextInput} value={this.state.texten} />
                
            </form>
        );
    }

};


ReactDOM.render(<div><Button /></div>, root);

