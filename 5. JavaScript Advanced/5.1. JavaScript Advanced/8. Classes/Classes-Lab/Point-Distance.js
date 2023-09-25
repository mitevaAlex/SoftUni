class Point {
    static distance(point1, point2) {
        let distance = Math.sqrt((point2.x - point1.x) ** 2 + (point2.y - point1.y) ** 2);
        return distance;
    }

    constructor(x, y) {
        this.x = x;
        this.y = y;
    }
}

// let p1 = new Point(5, 5);
// let p2 = new Point(9, 8);
// console.log(Point.distance(p1, p2));
