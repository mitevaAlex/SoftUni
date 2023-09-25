function convert(JSONdata) {
    let students = JSON.parse(JSONdata);
    console.log('<table>');
    let row = '\t<tr>';
    for (let key in students[0]) {
        row += `<th>${escapeHtml(key)}</th>`;
    }
    row += '</tr>';
    console.log(row);
    for (let student of students) {
        row = '\t<tr>'
        for (let key in student) {
            row += `<td>${escapeHtml(student[key])}</td>`;
        }
        row += '</tr>';
        console.log(row);
    }
    console.log('</table>');

    function escapeHtml(value) {
        return value
            .toString()
            .replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#39;');
    }
}

// convert(`[{"Name":"Stamat",
// "Score":5.5},
// {"Name":"Rumen",
// "Score":6}]`
// );
// convert(`[{"Name":"Pesho",
// "Score":4,
// "Grade":8},
// {"Name":"Gosho",
// "Score":5,
// "Grade":8},
// {"Name":"Angel",
// "Score":5.50,
// "Grade":10}]`
// );