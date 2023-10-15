var longitude = $("#Longitude").val() > 0 ? $("#Longitude").val() : "31.189944140292372";
var latitude = $("#Latitude").val() > 0 ? $("#Latitude").val() : "31.189944140292372";

async function initMap() {
	

	const { Map } = await google.maps.importLibrary("maps");

	let map = null;

	map = new Map(document.getElementById("map"), {
		center: { lat: latitude, lng: longitude },
		zoom: 14,
	});

	let marker = new google.maps.Marker({
		position: { lat: latitude, lng: longitude },
		map,
		draggable: true,
	});

	marker.addListener("dragend", e => {
		const position = marker.position;
		$('input[name=Latitude]').val(position.lat());
		$('input[name=Longitude]').val(position.lng());
	});

	map.addListener("click", (event) => {
		marker.setPosition(event.latLng);
		$('input[name=Latitude]').val(event.latLng.lat());
		$('input[name=Longitude]').val(event.latLng.lng());
	});

	// Start::ADD Search Box
	const input = document.getElementById("searchmap");
	const searchBox = new google.maps.places.SearchBox(input);

	map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);
	// Bias the SearchBox results towards current map's viewport.
	map.addListener("bounds_changed", () => {
		searchBox.setBounds(map.getBounds());
	});

	let markers = [];

	// Listen for the event fired when the user selects a prediction and retrieve
	// more details for that place.
	searchBox.addListener("places_changed", () => {
		const places = searchBox.getPlaces();

		if (places.length == 0) {
			return;
		}

		// Clear out the old markers.
		markers.forEach((marker) => {
			marker.setMap(null);
		});
		markers = [];

		// For each place, get the icon, name and location.
		const bounds = new google.maps.LatLngBounds();

		places.forEach((place) => {
			if (!place.geometry || !place.geometry.location) {
				console.log("Returned place contains no geometry");
				return;
			}

			const icon = {
				url: place.icon,
				size: new google.maps.Size(71, 71),
				origin: new google.maps.Point(0, 0),
				anchor: new google.maps.Point(17, 34),
				scaledSize: new google.maps.Size(25, 25),
			};

			// Create a marker for each place.

			if (place.geometry.viewport) {
				// Only geocodes have viewport.
				bounds.union(place.geometry.viewport);
			} else {
				bounds.extend(place.geometry.location);
			}
		});
		map.fitBounds(bounds);
	});
	// End::ADD Search Box
}
