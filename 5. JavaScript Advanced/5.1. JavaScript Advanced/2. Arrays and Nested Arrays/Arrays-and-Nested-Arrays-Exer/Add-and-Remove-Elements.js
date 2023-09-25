function manipulateArr(commands) {
    let arr = [];
    let commandCounter = 0;
    for (let i = 0; i < commands.length; i++) {
        switch (commands[i]) {
            case 'add':
                arr.push(++commandCounter);
                break;
            case 'remove':
                arr.pop();
                commandCounter++;
                break;
        }
    }

    if (arr.length == 0) {
        console.log('Empty');
    } else {
        console.log(arr.join('\n'));
    }
}

// manipulateArr(['add',
//     'add',
//     'add',
//     'add']
// );
// manipulateArr(['add',
//     'add',
//     'remove',
//     'add',
//     'add']
// );
// manipulateArr(['remove',
//     'remove',
//     'remove']
// );