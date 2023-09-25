function toStringExtension() {
    class Person {
        constructor(name, email) {
            this.name = name;
            this.email = email;
        }
    
        toString() {
            let result = `${this.constructor.name} (`;
            result += Object.keys(this).map(x => `${x}: ${this[x]}`).join(', ');
            result += ')';
    
            return result;
        }
    }
    
    class Teacher extends Person {
        constructor(name, email, subject) {
            super(name, email);
            this.subject = subject;
        }
    
        toString() {
            return super.toString();
        }
    }
    
    class Student extends Person {
        constructor(name, email, course) {
            super(name, email);
            this.course = course;
        }
    
        toString() {
            return super.toString();
        }
    }

    return {
        Person,
        Teacher,
        Student
    }
}