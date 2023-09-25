function extensibleObject() {
    let obj = {
        __proto__: {},
        extend(template) {
            for (let key in template) {
                let type = typeof (template[key]);
                if (typeof (template[key]) === 'function') {
                    Object.getPrototypeOf(this)[key] = template[key];
                } else {
                    Object.defineProperty(this, key, {value: template[key], writable: true});
                }
            }
        }
    };

    return obj;
}


// const myObj = extensibleObject();
// const template = {
//     extensionMethod: function () { },
//     extensionProperty: 'someString'
// }
// var template = {
//     fight: function (target) { return `object fights with ${target}` },
//     health: 100,
//     mana: 50
// };
// myObj.extend(template);
