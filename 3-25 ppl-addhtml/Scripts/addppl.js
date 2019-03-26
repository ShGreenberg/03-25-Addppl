$(() => {
    let count = 0;
    $("#add-more-ppl").on('click', function () {
        count++;
        console.log(count);
        $("#addppl").append(`<div class="row col-lg-offset-3"><input type="text" placeholder="first name" name="ppl[${count}].firstname" />
                <input type="text" placeholder="last name" name="ppl[${count}].lastname" />
                <input type="text" placeholder="age" name="ppl[${count}].age" /></div>`)
    });
});