function editElement(ref, elToReplace, replacer) {
    const text = ref.textContent;
    const matcher = new RegExp(elToReplace, 'g')

    ref.textContent = text.replace(matcher, replacer)
}

