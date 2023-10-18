import axios from "axios";
import Swal from "sweetalert2";

const axiosInstance = axios.create({
  baseURL: import.meta.env.VITE_API,
  headers: {
    "Content-Type": "application/json",
  },
});

axiosInstance.interceptors.response.use(
  function (response) {
    return response;
  },
  function (error) {
    if (error.response) {
      switch (error.response.status) {
        case 400:
          return handleError400(error);
        case 403:
          return handleError403();
        default:
          var detailErr =
            error.response.data.detail != undefined
              ? error.response.data.detail
              : error.message;
          displayError(detailErr);
      }
    } else if (error.request) {
      displayError("No response was received");
    } else {
      displayError(error.message);
    }

    return Promise.reject(error);
  }
);

async function handleError400(error) {
  var data = error.response.data;
  if (data.errors != undefined) {
    var message = "";
    Object.keys(data.errors).forEach((key) => {
      message = message + data.errors[key] + "<br>";
    });
    displayError(message);
  } else if (
    error.request.responseType === "blob" &&
    data instanceof Blob &&
    data.type &&
    data.type.toLowerCase().indexOf("json") != -1
  ) {
    const text = await data.text();
    var err = JSON.parse(text);
    displayError(err.detail);
  }
  if (data.detail != undefined) {
    displayError(data.detail);
  }
}

async function handleError403() {
  displayError("Permission denied.");
}

function displayError(message) {
  Swal.fire({
    title: "Error",
    html: message,
    icon: "error",
  });
}

export default axiosInstance;
