# Main goal

To build a 3D (Q-bic) TicTacToe online, first I want to create the API, and then focus on the UI

## Task list

- *Create the test artifacts* (Lesson learn?)
- Receive moves (the model could be named MoveInput)
- Calculate if the move results in a win
- ~~Move ServerSentEvents to a new project, as a library changing *public* accessibility to *internal*~~
- Test
- Adjust/Fix bugs (Lesson learn?)

## Limit (Outside the scope)

Although Server-Sent Event PoC was successful, it lacks some functionalities, like reconnection and disconnection. In other words, everything that is not strictly necessary to create MVP is outside of this iteration.

## Further iterations

A lot of space to improve the back, but I want to keep it simple as possible, next iteration will be the frontend.

- Create the Q-bic board, with React
- Add logic to place a mark on the board (X or O)
- Send move to backend

## Acquired lessons (After starting development)

- Webapp and backend are hosted in distinct origins, because ports are different, even being from the same host. Web browser adds a pre-flight request under certain circumstances like Cross-origin resource sharing (CORS). The lesson here is to add CORS policy to accept the requests, when you are working with multiple origins.
- As the application grows, communication between components is more complex, evidencing the importance of architecture. The lesson here is to define an architecture to follow.