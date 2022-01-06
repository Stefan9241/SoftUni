function solve(obj) {
  let validMethods = ["GET", "POST", "DELETE", "CONNECT"];
  let validVersions = ["HTTP/0.9", "HTTP/1.0", "HTTP/1.1", "HTTP/2.0"];
  let uriPattern = /(^[\w.]+$)/;
  let messagePattern = /([<>\\&'"])/;

  if (!obj.method || !validMethods.includes(obj.method)) {
    throw new Error("Invalid request header: Invalid Method");
  }

  if (!obj.uri || obj.uri == "" || !uriPattern.test(obj.uri)) {
    throw new Error("Invalid request header: Invalid URI");
  }

  if (!obj.version || !validVersions.includes(obj.version)) {
    throw new Error("Invalid request header: Invalid Version");
  }

  if (messagePattern.test(obj.message) || obj.message == undefined) {
    throw new Error("Invalid request header: Invalid Message");
  }

  return obj;
}

console.log(
  solve({
    method: "POST",
    uri: "home.bash",
    message: "rm -rf /*",
  })
);
