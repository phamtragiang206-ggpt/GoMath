// GoMath - site.js

// Auto-dismiss alerts
document.addEventListener('DOMContentLoaded', function () {
    const alerts = document.querySelectorAll('.auto-dismiss');
    alerts.forEach(function (alert) {
        setTimeout(function () {
            const bsAlert = bootstrap.Alert.getOrCreateInstance(alert);
            bsAlert.close();
        }, 4000);
    });

    // Animate cards on scroll
    const cards = document.querySelectorAll('.gm-card');
    if ('IntersectionObserver' in window) {
        const observer = new IntersectionObserver((entries) => {
            entries.forEach(entry => {
                if (entry.isIntersecting) {
                    entry.target.style.opacity = '1';
                    entry.target.style.transform = 'translateY(0)';
                }
            });
        }, { threshold: 0.1 });

        cards.forEach(card => {
            card.style.opacity = '0';
            card.style.transform = 'translateY(20px)';
            card.style.transition = 'opacity 0.4s ease, transform 0.4s ease';
            observer.observe(card);
        });
    }
});

// Unit converter: update unit options when category changes
function updateUnitOptions() {
    const category = document.getElementById('Category')?.value;
    const fromSelect = document.getElementById('FromUnit');
    const toSelect = document.getElementById('ToUnit');
    if (!category || !fromSelect || !toSelect) return;

    const unitMap = {
        'length': ['mm', 'cm', 'm', 'km'],
        'mass': ['g', 'kg', 'tấn'],
        'area': ['cm²', 'm²', 'ha', 'km²'],
        'volume': ['ml', 'lít', 'm³'],
        'time': ['giây', 'phút', 'giờ', 'ngày']
    };

    const units = unitMap[category] || [];
    fromSelect.innerHTML = '';
    toSelect.innerHTML = '';
    units.forEach(u => {
        fromSelect.add(new Option(u, u));
        toSelect.add(new Option(u, u));
    });
    if (units.length > 1) toSelect.selectedIndex = 1;
}

// Confirm delete
function confirmDelete(name) {
    return confirm(`Bạn có chắc muốn xóa học sinh "${name}" không?`);
}
