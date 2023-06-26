# Main goal

To build a 3D (Q-bic) TicTacToe online, first I want to create the API, and then focus on the UI

## Task list

- Create a model of response (MoveOutput)
- Create the API endpoint
- Send the response
- Test it

The model needs to have the **coordinate** of the move and if it's a **winner action** from the opponent, to stop or continue the game.

## Limit (Outside the scope)

The first iteration doesn't include the logic to receive moves or determine if a received move results in a winning outcome. Therefore it's just a PoC about the communication, especially the Server Side Event (SSE).

-- Edit --

After the first iteration, I found that due to no official implementation of SSE availability, this project requires more features development, like multisession (multiple client requests and possibly multithreading), which results in more challenges.

## Further iterations

- Receive moves (the model could be named MoveInput)
- Calculate if the move results in a win
- Move ServerSentEvents to a new project, as a library changing *public* accessibility to *internal*

## Acquired lessons (After starting development)

- SSE is not officially implemented, there is not straightforward way to create a controller. The lesson here is to do more research before start a project.
- TestDrivenDevelopment here is crucial, because Postman doesn't have SSE support (just from 10.10 and above, which I don't have). Lesson here is to start from a test view if you are experimenting with a new technology or concept.
- With testing, you will discover bugs and improvement opportunities which change the code. The lesson is always to add a task at the end of the iteration to refactor the code if required. I don't know if it's called iteration packaging, bug fix or adjustments, but some time is needed to close the iteration properly.