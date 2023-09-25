class Solution {
    static call(post, command) {
        switch (command) {
            case 'upvote':
                post.upvotes++;
                break;
            case 'downvote':
                post.downvotes++;
                break;
            case 'score':
                let report = [];
                let reportUpvotes;
                let reportDownvotes;
                if (post.upvotes + post.downvotes > 50) {
                    let numberAdded = Math.ceil((post.upvotes > post.downvotes ? post.upvotes : post.downvotes) * 0.25);
                    reportUpvotes = post.upvotes + numberAdded;
                    reportDownvotes = post.downvotes + numberAdded;
                } else {
                    reportUpvotes = post.upvotes;
                    reportDownvotes = post.downvotes;
                }

                let reportBalance = reportUpvotes - reportDownvotes;
                let rating;
                let totalVotes = post.upvotes + post.downvotes;
                if ((post.upvotes / (totalVotes)) * 100 > 66) {
                    rating = 'hot';
                } else if (reportBalance >= 0 && totalVotes > 100) {
                    rating = 'controversial';
                } else if (reportBalance < 0) {
                    rating = 'unpopular';
                } else {
                    rating = 'new';
                }

                if (totalVotes < 10) {
                    rating = 'new';
                }

                report.push(reportUpvotes, reportDownvotes, reportBalance, rating);
                return report;
        }
    }
}

// let post = {
//     id: '3',
//     author: 'emil',
//     content: 'wazaaaaa',
//     upvotes: 100,
//     downvotes: 100
// };
// Solution.call(post, 'upvote');
// Solution.call(post, 'downvote');
// let score = Solution.call(post, 'score'); // [127, 127, 0, 'controversial']
// for (let i = 0; i < 50; i++) {
//     Solution.call(post, 'downvote'); // (executed 50 times)
// }

// score = Solution.call(post, 'score'); // [139, 189, -50, 'unpopular']
