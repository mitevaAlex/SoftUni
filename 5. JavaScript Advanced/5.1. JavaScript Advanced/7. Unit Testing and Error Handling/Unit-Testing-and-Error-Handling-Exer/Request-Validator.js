function validateHttpRequest(request) {
    let errorMessage = 'Invalid request header: Invalid ';
    if (!request.hasOwnProperty('method')) {
        throw new Error(errorMessage + 'Method');
    }

    let validMethodValues = ['GET', 'POST', 'DELETE', 'CONNECT'];
    if (!validMethodValues.includes(request.method)) {
        throw new Error(errorMessage + 'Method');
    }

    if (!request.hasOwnProperty('uri')) {
        throw new Error(errorMessage + 'URI');
    }

    let uriRegex = new RegExp(/^[a-zA-Z\d.]+$|^\*$/);
    if (!request.uri.match(uriRegex)) {
        throw new Error(errorMessage + 'URI');
    }

    if (!request.hasOwnProperty('version')) {
        throw new Error(errorMessage + 'Version');
    }

    let validVersionValues = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
    if (!validVersionValues.includes(request.version)) {
        throw new Error(errorMessage + 'Version');
    }

    if (!request.hasOwnProperty('message')) {
        throw new Error(errorMessage + 'Message');
    }

    let messageRegex = new RegExp(/^[^\<\>\\&'"]*$/);
    if (!request.message.match(messageRegex)) {
        throw new Error(errorMessage + 'Message');
    }

    return request;
}

// console.log(validateHttpRequest({
//     method: 'GET',
//     uri: 'svn.public.catalog',
//     version: 'HTTP/1.1',
//     message: ''
// }
// ));

// console.log(validateHttpRequest({
//     method: 'OPTIONS',
//     uri: 'git.master',
//     version: 'HTTP/1.1',
//     message: '-recursive'
// }
// ));

// console.log(validateHttpRequest({
//     method: 'POST',
//     uri: 'home.bash',
//     message: 'rm -rf /*'
// }
// ));