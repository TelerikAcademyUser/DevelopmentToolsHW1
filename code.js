; //Because http://jshint.com/ says so. - Yet there are some errors from there that can't be fixed because it requare major change in the code
//or at least using the code in something
(function() {
	"use strict";

	var applicationName = navigator.appName;
	var addScroll = false;
	var theLayer;
	if ((navigator.userAgent.indexOf('MSIE 5') > 0) || (navigator.userAgent.indexOf('MSIE 6')) > 0) {
		addScroll = true;
	}
	var positionX = 0;
	var positionY = 0;
	document.onmousemove = mouseMove;
	if (applicationName === "Netscape") {
		document.captureEvents(Event.MOUSEMOVE);
	}

	function mouseMove(event) {

		if (applicationName === "Netscape") {
			positionX = event.pageX - 5;
			positionY = event.pageY;
		} else {
			positionX = event.x - 5;
			positionY = event.y;
		}
		if (applicationName === "Netscape") {
			if (document.layers.ToolTip.visibility === 'show') {
				popTip();
			}
		} else {
			if (document.all.ToolTip.style.visibility === 'visible') {
				popTip();
			}
		}
	}

	function popTip() {
		if (applicationName === "Netscape") {
			theLayer = document.layers.ToolTip;
			if ((positionX + 120) > window.innerWidth) {
				positionX = window.innerWidth - 150;
			}
			theLayer.left = positionX + 10;
			theLayer.top = positionY + 15;
			theLayer.visibility = 'show';
		} else {
			theLayer = document.all.ToolTip;
			if (theLayer) {
				positionX = event.x - 5;
				positionY = event.y;
				if (addScroll) {
					positionX = positionX + document.body.scrollLeft;
					positionY = positionY + document.body.scrollTop;
				}
				if ((positionX + 120) > document.body.clientWidth) {
					positionX = positionX - 150;
				}
				theLayer.style.pixelLeft = positionX + 10;
				theLayer.style.pixelTop = positionY + 15;
				theLayer.style.visibility = 'visible';
			}
		}
	}

	function hideTip() {
		if (applicationName === "Netscape") {
			document.layers.ToolTip.visibility = 'hide';
		} else {
			document.all.ToolTip.style.visibility = 'hidden';
		}
	}

	function hideMenuFirst() {
		if (applicationName === "Netscape") {
			document.layers.menuFirst.visibility = 'hide';
		} else {
			document.all.menuFirst.style.visibility = 'hidden';
		}
	}

	function showMenuFirst() {
		if (applicationName === "Netscape") {
			theLayer = document.layers.menuFirst;
			theLayer.visibility = 'show';
		} else {
			theLayer = document.all.menuFirst;
			theLayer.style.visibility = 'visible';
		}
	}

	function hideMenuSecond() {
		if (applicationName === "Netscape") {
			document.layers.menuSecond.visibility = 'hide';
		} else {
			document.all.menuSecond.style.visibility = 'hidden';
		}
	}

	function showMenuSecond() {
		if (applicationName === "Netscape") {
			theLayer = document.layers.menuSecond;
			theLayer.visibility = 'show';
		} else {
			theLayer = document.all.menuSecond;
			theLayer.style.visibility = 'visible';
		}
	}
})
();