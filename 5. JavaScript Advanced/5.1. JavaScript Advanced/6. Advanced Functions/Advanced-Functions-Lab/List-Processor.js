function solve(commands) {
    let processor = {
        list: [],
        add(string) {
            this.list.push(string);
        },
        remove(string) {
            this.list = this.list.filter(x => x !== string);
        },
        print() {
            console.log(this.list.join(','));
        }
    }

    for (let command of commands) {
        let commandArgs = command.split(' ');
        processor[commandArgs[0]](commandArgs[1]);
    }
}

// solve(['add hello', 'add again', 'remove hello', 'add again', 'print']);
// solve(['add pesho', 'add george', 'add peter', 'remove peter','print']);