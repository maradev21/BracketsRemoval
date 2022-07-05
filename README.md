# BracketsRemoval

This repository contains my solution for external brackets removal. The main code (containing the core logic) can be found inside `BracketsRemoval` project, while `BracketsRemoval.WebAPI` just exposes this functionality via HTTP.

# Run the API

## Swagger (debug)

Once this repository is cloned on your pc and you start a new debugging instance, a swagger page is immediately opened in your browser, through which you can easily invoke the API.

As an alternative, you can call the API through any client using the structures defined in the [next chapters](#Data-structure).

## Docker

This solution is released as docker image on docker hub. To install and run it, run the following commands:

```
docker pull maradev21/bracketsremoval
docker run -p [yourPort]:5000 maradev21/bracketsremoval
```

# Usage

Regardless of the deploying technology, the API can be reached at the following endpoint with a POST request: `http://[yourMachine]:[yourPort]/bracketsRemoval`.

`[yourPort]` corresponds to the port specified in the `docker run` command. By default at debug time, it is 5000.

## Request

The POST request has to follow this structure, where `dirtyText` contains the text with the extra brackets to be removed and `timestamp` represents the time of when the request is performed:

```json
{
  "dirtyText": "(((your text with brackets)))",
  "timestamp": "2022-07-04T12:00:000"
}
```

## Response

The returned response follows this structure:

```json
{
  "request": {
    "dirtyText": "(((your text with brackets)))",
    "timestamp": "2022-07-04T12:00:000"
  },
  "cleanText": "your text with brackets",
  "errorMessage": "",
  "timestamp": "2022-07-04T12:00:00.500Z"
}
```

`request` is the received request to which this response is associated, while `cleanText` is the returned text without extra brackets. `errorMessage` is set only when pathological inputs are provided, to explain why the passed `dirtyText` cannot be processed. In those cases, `cleanText` is empty, as in the following example:

```json
{
  "request": {
    "dirtyText": "(((your text with pathological brackets))(((",
    "timestamp": "2022-07-04T12:00:000"
  },
  "cleanText": "",
  "errorMessage": "The passed text is pathological: not all brackets are correctly opened or closed.",
  "timestamp": "2022-07-04T12:00:00.500Z"
}
```

As it happens for the request, response's `timestamp` represents the time at which the response is generated.
