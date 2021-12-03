# Description

This project aims to solve the issue of querying data about Azure Friday episodes as portrayed
in [this video](https://www.youtube.com/watch?v=dqNLBJKpNAI) by [Scott Hanselman](https://www.youtube.com/c/shanselman).

## API insights

The maximum number of entry IDs for which to run a batch query on the video API seems to be 52, which results in a URI
with a total length of 2090 characters. Adding another GUID leads to the
response `The resource you are looking for has been removed, had its name changed, or is temporarily unavailable.` as
can be seen in the video.

## Error handling

Since the project is intended to solve the issue in a "quick and dirty" fashion, the implementation does not explicitly
handle errors by the called `Show` and `Videos` APIs.