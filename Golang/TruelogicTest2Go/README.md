# Return usernames

Write a function that, based on the threshold provided via parameters, return a list of users whose amount of submissions is strictly greater than the threshold.

User data must be fetched by GET requests to url https://url.com. Response has pagination (starting at 1), so keep requesting until all pages were read.

Response will have the following properties:

- page: int (current page retrieved)
- total_pages: int (total amount of pages available to be retrieved)
- posts: []any (array of objects with posts available)
- data: []any (array of objects with user data)

## Posts

Each post have these properties:

- title: string
- subtitle: string
- tags: []string
- content: any (an html element)
- author: string

## Data

Each user data object have the following properties:

- name: string
- username: string
- created_at: date
- e-mail: string
- total_submissions: int
- last_submission: date
