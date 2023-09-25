function solve(commands) {
    let processor = {
        objects: {},
        create(name) {
            this.objects[name] = {};
        },
        createAndInherit(name, parentName) {
            this.objects[name] = Object.create(this.objects[parentName]);
        },
        set(name, key, value) {
            this.objects[name][key] = value;
        },
        print(name) {
            let resultArr = [];
            for (let key in this.objects[name]) {
                resultArr.push(`${key}:${this.objects[name][key]}`);
            }
            console.log(resultArr.join(','));
        }
    }

    for (let command of commands) {
        let commandArgs = command.split(' ');
        if (commandArgs.length === 2) {
            processor[commandArgs[0]](commandArgs[1]);
        } else if (commandArgs.length === 4) {
            if (commandArgs[0] === 'create') {
                processor.createAndInherit(commandArgs[1], commandArgs[3]);
            } else if (commandArgs[0] === 'set') {
                processor[commandArgs[0]](commandArgs[1], commandArgs[2], commandArgs[3]);
            }
        }
    }
}


// solve(['create c1',
//     'create c2 inherit c1',
//     'set c1 color red',
//     'set c2 model new',
//     'print c1',
//     'print c2']
// );