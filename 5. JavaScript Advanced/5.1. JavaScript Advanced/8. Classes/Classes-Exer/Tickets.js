function ticketDatabase(ticketsInfo, sortCriteria) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let tickets = [];
    for (let ticketArgs of ticketsInfo) {
        ticketArgs = ticketArgs.split('|');
        tickets.push(new Ticket(ticketArgs[0], Number(ticketArgs[1]), ticketArgs[2]));
    }

    tickets.sort((a, b) => {
        a = a[sortCriteria];
        b = b[sortCriteria];
        if (a > b) return 1;
        if (a < b) return -1;
        if (a == b) return 0;
    });
    return tickets;
}

// console.log(ticketDatabase(['Philadelphia|94.20|available',
//     'New York City|95.99|available',
//     'New York City|95.99|sold',
//     'Boston|126.20|departed'],
//     'destination'
// ));

// console.log(ticketDatabase(['Philadelphia|94.20|available',
//     'New York City|95.99|available',
//     'New York City|95.99|sold',
//     'Boston|126.20|departed'],
//     'status'
// ));