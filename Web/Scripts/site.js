var loader = $('#loader-holder');

function LoaderOn() {
    loader.removeAttr('hidden');
}

function LoaderOff() {
    loader.attr('hidden', true);
}